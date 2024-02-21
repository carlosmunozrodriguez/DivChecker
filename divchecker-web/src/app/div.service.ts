import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DivService {
  constructor(private http: HttpClient) {
  }

  getResults(input1: number, input2: number, sampleSize: number) {
    return this.http.get<NumberResultPair[]>(`${environment.baseUrl}/divs`, {
      params: {
        input1: input1.toString(),
        input2: input2.toString(),
        sampleSize: sampleSize.toString()
      }
    });
  }
}
