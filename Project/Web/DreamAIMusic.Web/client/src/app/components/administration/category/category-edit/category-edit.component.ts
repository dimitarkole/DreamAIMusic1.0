import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from '../../../../core/services/category.service';
import Category from '../../../shared/models/category';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
  category: Category;
  nameMinLength = 2;
  nameMaxLength = 30;
  categoryForm: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private categoryService: CategoryService,
    public modal: NgbActiveModal) { }

  ngOnInit() {
    this.categoryForm = this.formBuilder.group({
      name: [
        this.category.name,
        [
          Validators.required,
          Validators.minLength(this.nameMinLength),
          Validators.maxLength(this.nameMaxLength)
        ]
      ],
      id: this.category.id
    })
  }

  OnSubmit() {
    let category: Category = this.categoryForm.value;

    this.categoryService.edit(category)
      .subscribe(_ => {
        this.modal.close(); //It closes successfully
      })   
  }

  get name(): AbstractControl {
    return this.categoryForm.get('name');
  }
}
