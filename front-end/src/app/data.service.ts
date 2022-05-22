import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(
    private http: HttpClient,
  ) { }

  getSvg() {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    const url = "https://localhost:5001/api/svgjson/all";
    return this.http.get(url,{ headers: headers })
  }

  updateSvg(id:string, svg:any) {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    const url = `https://localhost:5001/api/svgjson/${id}`;
    return this.http.patch(url, svg, { headers: headers })
  }

}
