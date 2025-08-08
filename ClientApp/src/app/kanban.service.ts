import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// --- Interfaces for your backend models ---
export interface Project {
  id: number;
  title: string;
  ownerId: number;
}

export interface User {
  id: number;
  username: string;
}

export interface Task {
  id: number;
  title: string;
  description: string;
  assignedTo: string; // The name of the assignee
  status: string; // "To Do", "Doing", "Done"
  columnId: number;
  assignedToId: number;
}

export interface TaskColumn {
  id: number;
  title: string;
  projectId: number;
}

@Injectable({
  providedIn: 'root'
})
export class KanbanService {
  private apiUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  // --- Projects Endpoints ---
  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}Projects`);
  }
  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}Projects/${id}`);
  }
  createProject(project: Project): Observable<Project> {
    return this.http.post<Project>(`${this.apiUrl}Projects`, project);
  }
  updateProject(id: number, project: Project): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}Projects/${id}`, project);
  }
  deleteProject(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}Projects/${id}`);
  }

  // --- Users Endpoints ---
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}Users`);
  }
  // You would add more methods for users (create, update, delete) here as needed.

  // --- TaskColumns Endpoints ---
  getTaskColumns(): Observable<TaskColumn[]> {
    return this.http.get<TaskColumn[]>(`${this.apiUrl}TaskColumns`);
  }
  // You would add more methods for task columns here.

  // --- Tasks Endpoints ---
  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}Tasks`);
  }
  createTask(task: Task): Observable<Task> {
    return this.http.post<Task>(`${this.apiUrl}Tasks`, task);
  }
  updateTask(id: number, task: Task): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}Tasks/${id}`, task);
  }
  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}Tasks/${id}`);
  }
}
