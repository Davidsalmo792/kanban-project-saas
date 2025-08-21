import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskComponent } from '../task/task.component';
import { Task, TaskColumn } from '../kanban.service';

@Component({
  selector: 'app-column',
  standalone: true,
  imports: [CommonModule, TaskComponent],
  templateUrl: './column.component.html',
  styleUrls: ['./column.component.css']
})
export class ColumnComponent {
  @Input() column!: TaskColumn;
  @Input() tasks: Task[] = [];
}
