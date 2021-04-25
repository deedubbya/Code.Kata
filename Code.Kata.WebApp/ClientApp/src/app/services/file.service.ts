import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http: HttpClient) { }

  public UploadFile(formData) {
    return this.http.post("https://localhost:44391/api/File/FileUpload", formData, {
      reportProgress: true,
      observe: 'events'
    })
  }
}
