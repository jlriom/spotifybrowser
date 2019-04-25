import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/core/music/category.service';
import { Router } from '@angular/router';
import { CategoryViewModel } from '../../view-models/category-view-model';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html'
})
export class CategoriesComponent implements OnInit {

  categories: CategoryViewModel[];

  constructor(private categoryService: CategoryService, private router: Router) { }

  ngOnInit() {
    this.categoryService.GetCategories().subscribe( r => {
      this.categories = r.items
        ? r.items.map(category => new CategoryViewModel(category))
        : [];
    });
  }

  onCategoryClicked(categoryViewModel: CategoryViewModel) {
    this.router.navigate(['browse/category', categoryViewModel.id]);
  }
}
