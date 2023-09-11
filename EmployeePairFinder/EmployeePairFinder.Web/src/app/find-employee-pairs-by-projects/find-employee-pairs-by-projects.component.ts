import { Component, OnDestroy, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeePair } from '../models/employee-pair.model';

@Component({
  selector: 'app-find-employee-pairs-by-projects',
  templateUrl: './find-employee-pairs-by-projects.component.html',
  styleUrls: ['./find-employee-pairs-by-projects.component.css']
})
export class FindEmployeePairsByProjectsComponent implements OnDestroy {
  subscription!: Subscription;
  employeePairs: EmployeePair[] = [];
  selectedFile?: File;
  columnsToDisplay = ['firstEmployee', 'secondEmployee', 'durationInDays', 'projectID'];

  constructor(private employeeService: EmployeeService, private matSnackBar: MatSnackBar) { }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
    if (this.selectedFile) {
      if (this.isFileTypeValid(this.selectedFile.type)) {
        this.subscription = this.employeeService.$post(this.selectedFile!).subscribe({
          next: (response: EmployeePair[]) => {
            this.employeePairs = response;
            this.matSnackBar.open('File was uploaded successfully. You can now see which pair has worked the most on common projects.', 'X',
              {
                duration: 6000
              });
          },
          error: (errorResponse: any) => {
            this.matSnackBar.open('An error occured. Please check the format of your csv file. It must not have space in between the comma delimiter.', 'X');
          }
        });
      }
      else {
        this.matSnackBar.open('Please upload a csv file!', 'X');
      }
    }
    else {
      this.matSnackBar.open('Please upload a file!', 'X');
    }
  }

  isFileTypeValid(fileType: string): Boolean {
    let allowedFileTypes: string[] = ['text/csv'];
    if (allowedFileTypes.find(allowedFileType => allowedFileType === fileType)) {
      return true;
    }

    return false;
  }
}
