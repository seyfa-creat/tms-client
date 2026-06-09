export function parseStudent(raw: unknown): Student {
if (typeof raw !== "object" || raw === null) {
throw new TypeError(
`Expected an object, received ${raw === null ? "null" : typeof raw}`,
);
}
const obj = raw as Record<string, unknown>;
if (typeof obj.id !== "string") {
throw new TypeError(
`Expected id to be a string, received ${typeof obj.id}`,
);
}
if (typeof obj.name !== "string") {
throw new TypeError(
`Expected name to be a string, received ${typeof obj.name}`,
);
}
return {
id: obj.id,
name: obj.name,
enrollmentDate: Temporal.Now.instant(),
};
}
Test it in index.ts:
import { parseStudent } from "./models/student.model";
console.log(parseStudent({ id: "STU-001", name: "Hana" }));
// Prints a valid Student object
parseStudent({ id: 42, name: "Test" });
// Throws: TypeError: Expected id to be a string, received number
