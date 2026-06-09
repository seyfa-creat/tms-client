// Legacy dangerous
function processStudent(data: any) {
console.log(`GPA: ${data.gpa.toFixed(2)}`); // Crashes if gpa is missing or not a number
}
export function isStudent(value: unknown): value is Student {
return (
typeof value === "object" &&
value !== null &&
"id" in value &&
"name" in value &&
typeof (value as Record<string, unknown>).id === "string" &&
typeof (value as Record<string, unknown>).name === "string"
);
}
Nowinindex.ts, import and use it:
import { Student, isStudent } from "./models/student.model";
function processStudent(raw: unknown) {
if (isStudent(raw)) {
const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
} else {
console.error("Invalid student data received");
}
}
processStudent({ id: "STU-001", name: "Hana", gpa: 3.7 });
// Prints: Student Hana GPA: 3.70
processStudent(42);
// Prints: Invalid student data received