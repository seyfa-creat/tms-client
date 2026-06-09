Create a new file models/assessment.model.ts:
export interface Quiz {
readonly id: string;
kind: "quiz";
title: string;
correctAnswers: number;
totalQuestions: number;
}
export interface LabAssignment {
readonly id: string;
kind: "lab";
title: string;
functionalityScore: number;
codeQualityScore: number;
}
export type AssessmentItem = Quiz | LabAssignment;
Step 2 Write the Grade Calculator
Addthis function to the same file, below the type:
export function calculateGrade(item: AssessmentItem): number {
switch (item.kind) {
case "quiz":
return Math.round((item.correctAnswers / item.totalQuestions) * 100);
case "lab":
return Math.round(
item.functionalityScore * 0.7 + item.codeQualityScore * 0.3,
);
}
}
In index.ts, import and test:
import { AssessmentItem, calculateGrade } from "./models/assessment.model";
const quiz: AssessmentItem = {
id: "QUIZ-001",
kind: "quiz",
title: "SQL Basics",
correctAnswers: 8,
totalQuestions: 10,
};
const lab: AssessmentItem = {
id: "LAB-001",
kind: "lab",
title: "REST API Project",
functionalityScore: 85,
codeQualityScore: 90,
};
console.log(`Quiz grade: ${calculateGrade(quiz)}%`); // 80
console.log(`Lab grade: ${calculateGrade(lab)}%`); // 87
// Verify readonly try this line and check the compiler error:
quiz.id = "QUIZ-999";
// ERROR: Cannot assign to 'id' because it is a read-only property
