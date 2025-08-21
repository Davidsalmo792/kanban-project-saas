import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Task } from '../kanban.service';

@Component({
  selector: 'app-task',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  @Input() task!: Task;
}
