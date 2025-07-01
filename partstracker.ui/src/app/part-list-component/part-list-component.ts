import { Component, OnInit } from '@angular/core';
import { Part } from '../models/part';
import { PartService } from '../services/part.service';
import { Router } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-part-list',
  templateUrl: './part-list-component.html',
  styleUrls: ['./part-list-component.scss'],
  imports: [CommonModule,DatePipe],
})
export class PartListComponent implements OnInit {
  parts: Part[] = [];
  loading = false;
  error = '';

  constructor(private partService: PartService, private router: Router) {}

  ngOnInit(): void {
    this.loadParts();
  }

  loadParts(): void {
    this.loading = true;
    this.partService.getAll().subscribe({
      next: (data: Part[]) => {
        this.parts = data;
        this.loading = false;
      },
      error: (err: any) => {
        this.error = 'Failed to load parts';
        this.loading = false;
      },
    });
  }

  view(id: string) {
    this.router.navigate([id]);
  }

  edit(id: string) {
    this.router.navigate([id, 'edit']);
  }

  delete(id: string) {
    if (confirm('Are you sure you want to delete this part?')) {
      this.partService.delete(id).subscribe({
        next: () => this.loadParts(),
        error: () => alert('Delete failed'),
      });
    }
  }

  create() {
    this.router.navigate(['/create']);
  }
}