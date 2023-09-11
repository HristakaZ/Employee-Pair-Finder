import { Employee } from "./employee.model";

export class EmployeePair {
    firstEmployee!: Employee;
    secondEmployee!: Employee;
    durationInDays!: number;
    projectID!: number;
    error?: string;
}