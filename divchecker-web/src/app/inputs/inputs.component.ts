import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inputs',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './inputs.component.html',
  styleUrl: './inputs.component.css'
})

export class InputsComponent {
  inputsForm = new FormGroup({
    input1: new FormControl(1),
    input2: new FormControl(1),
    sampleSize: new FormControl(0)
  });

  constructor(private router: Router) {
  }

  submit() {
    const form = this.inputsForm.value;
    this.router.navigate(['results'], { queryParams: { input1: form.input1, input2: form.input2, sampleSize: form.sampleSize } });
  }
}
