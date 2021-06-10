export class Task {
    constructor(
        public id?: string,
        public title?: string,
        public description?: string,
        public dueDateTiem?: Date,
        public priority?: number) { }
}