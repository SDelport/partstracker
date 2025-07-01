import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { PartService } from '../services/part.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Part } from '../models/part';

@Component({
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  selector: 'app-part-form',
  templateUrl: './part-form.html',
  styleUrls: ['./part-form.scss'],
})
export class PartFormComponent implements OnInit {

  form!: FormGroup;

  errors: Record<string, string[]> = {};
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private partService: PartService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.form = this.fb.group({
      partNumber: ['', Validators.required],
      description: ['', Validators.required],
      quantityOnHand: [0, [Validators.required, Validators.min(0)]],
      locationCode: ['', Validators.required],
      lastStockTake: ['', Validators.required],
    });

    if (id) {
      this.isEditMode = true;
      this.partService.get(id).subscribe(part => {
        this.form.patchValue({
          partNumber: part.partNumber,
          description: part.description,
          quantityOnHand: part.quantityOnHand,
          locationCode: part.locationCode,
          lastStockTake: part.lastStockTake.slice(0, 10), // format YYYY-MM-DD for input[type=date]
        });
        this.form.controls['partNumber'].disable(); // PK not editable
      });
    }
  }

  onSubmit(): void {
    this.errors = {};
    if (this.form.invalid) return;

    const formValue = this.isEditMode
      ? { ...this.form.getRawValue() }
      : this.form.value;

    const action = this.isEditMode
      ? this.partService.update(formValue.partNumber!, formValue as Part)
      : this.partService.create(formValue as Part);

    action.subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => {
        this.errors = err || {};
      },
    });
  }

  onCancel(): void {
    this.router.navigate(['/']);
  }
}