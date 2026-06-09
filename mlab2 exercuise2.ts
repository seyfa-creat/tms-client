Create models/student.model.ts:
import { Temporal } from "@js-temporal/polyfill";
export interface Student {
readonly id: string;
name: string;
enrollmentDate: Temporal.Instant;
gpa?: number; // Optional undefined until the student receives a grade
}
Create models/course.model.ts:
import { Temporal } from "@js-temporal/polyfill";
export interface Course {
readonly id: string;
title: string;
capacity: number;
startDate?: Temporal.PlainDate;
}
Create models/enrollment.model.ts:
import { Temporal } from "@js-temporal/polyfill";
export interface EnrollmentRecord {
readonly studentId: string;
readonly courseCode: string;
enrolledAt: Temporal.Instant;
}
mport { Temporal } from "@js-temporal/polyfill";
import { Student } from "./models/student.model";
const student: Student = {
id: "STU-001",
name: "Hana Tadesse",
enrollmentDate: Temporal.Now.instant(),
};
// Try these what does the compiler say?
student.id = "STU-999";
console.log(student.gpa.toFixed(2));
console.log(student.gpa?.toFixed(2) ?? "Not yet graded");
