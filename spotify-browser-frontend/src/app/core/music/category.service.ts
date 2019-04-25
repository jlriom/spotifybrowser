import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Category } from './model/category';
import { Paging } from '../paging';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }

  GetCategories(limit: number = 50, offset: number = 0): Observable<Paging<Category>> {
    const params = new HttpParams()
      .set('limit', limit.toString())
      .set('offset', offset.toString());

    return this.httpClient.get<Paging<Category>>(environment.apiReadRoot + 'Category/GetCategories', { params: params });
  }

  GetCategory(categoryId: string): Observable<Category> {

    const params = new HttpParams()
      .set('categoryId', categoryId.toString());

    return this.httpClient.get<Category>(environment.apiReadRoot + 'Category/GetCategory', { params: params });
  }
}
