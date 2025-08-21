import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common'; // Import CommonModule for directives like *ngIf and *ngFor

// This is an interface to match the Project model in your backend API
interface Project {
  id: number;
  title: string;
  ownerId: number;
}

@Component({
  selector: 'app-root',
  standalone: true, // This is a standalone component
  imports: [CommonModule, HttpClientModule], // Import necessary modules
  template: `
    <div class="container mx-auto p-8 font-sans bg-gray-100 min-h-screen">
      <header class="text-center mb-8">
        <h1 class="text-4xl font-bold text-gray-800">My Kanban Projects</h1>
      </header>
      
      <!-- Display a loading message while data is being fetched -->
      <div *ngIf="loading" class="text-center text-gray-500 text-lg">Loading projects...</div>
      
      <!-- Display an error message if the API call fails -->
      <div *ngIf="error" class="text-center text-red-500 text-lg">Error: {{ error }}</div>
      
      <!-- Display the list of projects if data is available -->
      <div *ngIf="projects.length > 0; else noProjects" class="bg-white rounded-lg shadow-md p-6">
        <ul class="space-y-4">
          <li *ngFor="let project of projects" class="border-b pb-2 last:border-b-0">
            <h2 class="text-xl font-semibold text-gray-700">{{ project.title }}</h2>
            <p class="text-sm text-gray-500">Owner ID: {{ project.ownerId }}</p>
          </li>
        </ul>
      </div>
      
      <!-- Display a message when no projects are found -->
      <ng-template #noProjects>
        <p class="text-center text-gray-500 text-lg">No projects found. Make sure your backend API is running and has data.</p>
      </ng-template>
    </div>
  `,
})
export class AppComponent implements OnInit {
  projects: Project[] = [];
  loading = true;
  error: string | null = null;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    // This is the URL of your backend API's Projects endpoint.
    // Make sure your backend is running on http://localhost:5000
    this.http.get<Project[]>('http://localhost:5000/api/Projects')
      .subscribe({
        next: (data) => {
          this.projects = data;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error fetching data:', err);
          this.error = err.message;
          this.loading = false;
        }
      });
  }
}
