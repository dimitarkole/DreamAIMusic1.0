import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './auth/signup/signup.component';
import { LoginComponent } from './auth/login/login.component';
import { CategoryCreateComponent } from './components/administration/category/category-create/category-create.component';
import { CategoryListComponent } from './components/administration/category/category-list/category-list.component';
import { SongCreateComponent } from './components/user/song/song-create/song-create.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'category', children: [
      { path: '', component: CategoryListComponent },
      { path: 'all', component: CategoryListComponent },
      { path: 'create', component: CategoryCreateComponent },
    ]
  },
  {
    path: 'song', children: [
      { path: 'create', component: SongCreateComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
