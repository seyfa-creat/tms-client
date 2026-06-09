Add the CourseStatus type to models/course.model.ts:
export type CourseStatus =
| { status: "DRAFT"; createdBy: string; createdAt: Temporal.Instant }
| { status: "PUBLISHED"; publishedAt: Temporal.Instant; syllabus: string }
| {
status: "ACTIVE";
enrolledCount: number;
startDate: Temporal.PlainDate;
}
| {
status: "ARCHIVED";
archivedAt: Temporal.Instant;
finalEnrollmentCount: number;
}
| { status: "CANCELLED"; reason: string; cancelledAt: Temporal.Instant };
export function describeCourse(status: CourseStatus): string {
// Your switch goes here. Handle all 5 states.
// Each case should return a descriptive string using the state-specific fields.
// Include the default/never check.
}
Test it in index.ts with an ACTIVE course:
import { CourseStatus, describeCourse } from "./models/course.model";
const webDev: CourseStatus = {
status: "ACTIVE",
enrolledCount: 28,
startDate: Temporal.PlainDate.from("2026-09-01"),
};
console.log(describeCourse(webDev));
// Should print something like: Active with 28 students since 2026-09-01
// Before generics repetitive
type StudentResponse =
| { status: "loading" }
| { status: "success"; data: Student; fetchedAt: Temporal.Instant }
| { status: "error"; message: string; statusCode: number };
type CourseListResponse =
| { status: "loading" }
| { status: "success"; data: Course[]; fetchedAt: Temporal.Instant }
| { status: "error"; message: string; statusCode: number };
Create models/api-response.model.ts:
import { Temporal } from "@js-temporal/polyfill";
export type ApiResponse<T> =
| { status: "loading" }
| { status: "success"; data: T; fetchedAt: Temporal.Instant }
| { status: "error"; message: string; statusCode: number };
Step 2 Write the Renderer
You have nowwritten three exhaustive switch blocks (calculateGrade, describeEnrollment,
describeCourse). This is the same pattern only the types are generic. Write the function
body yourself:
export function renderResponse<T>(
response: ApiResponse<T>,
formatter: (data: T) => string,
): string {
// TODO: Handle all three states with a switch on response.status.
// "loading" → return "Loading..."
// "success" → call the formatter with response.data
// "error" → return a string with the statusCode and message
}
import { ApiResponse, renderResponse } from "./models/api-response.model";
import { Student } from "./models/student.model";
import { Course } from "./models/course.model";
const studentRes: ApiResponse<Student> = {
status: "success",
data: {
id: "STU-001",
name: "Dawit Bekele",
enrollmentDate: Temporal.Now.instant(),
gpa: 3.4,
},
fetchedAt: Temporal.Now.instant(),
};
console.log(
renderResponse(studentRes, (s) => `${s.name} GPA: ${s.gpa ?? "N/A"}`),
);
// Nowtest with a different data type
const courseListRes: ApiResponse<Course[]> = {
status: "success",
data: [
{
id: "CRS-101",
title: "Web Development Fundamentals",
capacity: 30,
startDate: Temporal.PlainDate.from("2026-09-01"),
},
],
fetchedAt: Temporal.Now.instant(),
};
console.log(
renderResponse(courseListRes, (courses) =>
courses.map((c) => c.title).join(", "),
),
);
/ 1. Record the exact moment an enrollment is approved (UTC)
const approvedAt = Temporal.Now.instant();
console.log(`Approved at (UTC): ${approvedAt}`);
// 2. Display in local timezone
const addisTime = approvedAt.toZonedDateTimeISO("Africa/Addis_Ababa");
const londonTime = approvedAt.toZonedDateTimeISO("Europe/London");
console.log(`Addis: ${addisTime.toPlainTime()}`);
console.log(`London: ${londonTime.toPlainTime()}`);
// Same moment, different wall-clock time
// 3. Course start date (date only, no time)
const courseStart = Temporal.PlainDate.from("2026-09-01");
const today = Temporal.Now.plainDateISO();
const daysUntilStart = today.until(courseStart).total({ unit: "days" });
console.log(`${Math.floor(daysUntilStart)} days until course starts`);
// 4. Assignment deadline duration
const deadline = Temporal.PlainDate.from("2026-12-15");
const remaining = today.until(deadline);
console.log(
`${remaining.total({ unit: "days" })} days until assignment is due`,
);
