import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../config/constants';
import { DriverReportData } from '../models/driver-report-data';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  constructor(private http: HttpClient, private constants: Constants) { }

  public GetDriverReportData() {
    return this.http.get<DriverReportData[]>(this.constants.API_ENDPOINT + "/Driver/GetDriverReportData")
  }
}
