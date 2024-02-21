import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { DivService } from '../div.service';
import { ActivatedRoute, Router } from '@angular/router';
import { YesNoResultPipe } from '../pipes/YesNoResult.pipe';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-results',
  standalone: true,
  imports: [CommonModule, YesNoResultPipe],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export class ResultsComponent {

  constructor(private divService: DivService, private router: Router, private route: ActivatedRoute) { }

  results: NumberResultPair[] = [];
  errors: string[] = [];

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const input1 = parseInt(params['input1']);
      const input2 = parseInt(params['input2']);
      const sampleSize = parseInt(params['sampleSize']);

      this.divService.getResults(input1, input2, sampleSize)
        .subscribe({
            next: results => this.results = results,
            error: (error: HttpErrorResponse) => {
              if (error.status === 400 && Array.isArray(error.error)) {
                this.errors = error.error as string[];
              }
            }
        });
      });
  }

  back() {
    this.router.navigate(['']);
  }
}
