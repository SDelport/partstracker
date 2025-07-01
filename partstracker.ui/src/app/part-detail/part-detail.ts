import { Component, OnInit } from '@angular/core';
import { Part } from '../models/part';
import { PartService } from '../services/part.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-part-detail',
  templateUrl: './part-detail.html',
  styleUrls: ['./part-detail.scss'],
})
export class PartDetailComponent implements OnInit {
  part: Part | null = null;
  loading = true;
  error = '';

  constructor(
    private partService: PartService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.partService.get(id).subscribe({
        next: (p) => {
          this.part = p;
          this.loading = false;
        },
        error: () => {
          this.error = 'Failed to load part';
          this.loading = false;
        },
      });
    }
  }

  goBack() {
    this.router.navigate(['/']);
  }
}