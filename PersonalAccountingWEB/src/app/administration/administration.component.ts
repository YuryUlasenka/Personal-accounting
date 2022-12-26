import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent implements OnInit{
  data?: WeatherForecast[];

  constructor(private http: HttpClient){}

  ngOnInit() {
    this.http.get<WeatherForecast[]>("api/weatherforecast")
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
