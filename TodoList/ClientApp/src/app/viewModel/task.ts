export class Task {
    constructor(
        public id?: string,
        public title?: string,
        public description?: string,
        public dueDateTime?: Date,
        public priority?: number) { }
}