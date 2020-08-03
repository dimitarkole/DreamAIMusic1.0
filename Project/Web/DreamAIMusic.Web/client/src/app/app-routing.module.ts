import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './auth/signup/signup.component';
import { LoginComponent } from './auth/login/login.component';
import { CategoryCreateComponent } from './components/administration/category/category-create/category-create.component';
import { CategoryListComponent } from './components/administration/category/category-list/category-list.component';
import { SongCreateComponent } from './components/user/song/song-create/song-create.component';
import { SongListComponent } from './components/user/song/song-list/song-list.component';
import { SongEditComponent } from './components/user/song/song-edit/song-edit.component';
import { SongResolver } from './core/resolvers/song.resolver';

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
      { path: '', component: SongListComponent },
      { path: 'all', component: SongListComponent },
      { path: 'create', component: SongCreateComponent },
      {
        path: 'edit/:id',
        component: SongEditComponent,
        resolve:
        {
          song: SongResolver
        } 
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
