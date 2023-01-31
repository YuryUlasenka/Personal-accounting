import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-weather-page',
  templateUrl: './weather-page.component.html',
  styleUrls: ['./weather-page.component.css']
})
export class WeatherPageComponent {
  data?: WeatherForecast[];

  constructor(private http: HttpClient){}

  ngOnInit() {
    this.http.get<WeatherForecast[]>("/api/weatherforecast")
      .subscribe({
        next: (result) => this.data = result,
        error: (err: HttpErrorResponse) => console.log(err)
      })
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
