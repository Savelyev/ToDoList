export class TaskViewModel {
    constructor(
        public id?: string,
        public title?: string,
        public description?: string,
        public dueTime?: string,
        public dueDate?: string,
        public notificationPeriod?: string,
        public priority?: string
    ) { }
}