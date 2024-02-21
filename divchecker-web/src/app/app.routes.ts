import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { InputsComponent } from './inputs/inputs.component';
import { ResultsComponent } from './results/results.component';

export const routes: Routes = [
  {
    path: '',
    component: InputsComponent,
    title: 'Division checker'
  },
  {
    path: 'results',
    component: ResultsComponent,
    title: 'Results'
  }
];
