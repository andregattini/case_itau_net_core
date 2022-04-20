import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherForecast } from 'src/app/models/watherforecast';
import { WeatherForecastService } from 'src/app/services/watherforecastService';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, service :WeatherForecastService ) {
      service.getWeatherForecastService().subscribe(res => {
       this.forecasts = res;
    });
  }
}



