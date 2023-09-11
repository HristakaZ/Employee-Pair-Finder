import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FindEmployeePairsByProjectsComponent } from './find-employee-pairs-by-projects/find-employee-pairs-by-projects.component';

const routes: Routes = [
  { path: '', component: FindEmployeePairsByProjectsComponent },
  { path: 'employee/findEmployeePairsByProjects', component: FindEmployeePairsByProjectsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
