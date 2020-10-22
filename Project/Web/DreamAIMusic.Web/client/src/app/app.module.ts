import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule, NgbDropdownModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { BaseUrlInterceptor } from './core/interceptors/base-url.interceptor';
import { NavBarComponent } from './components/shared/nav-bar/nav-bar.component';
import { FooterComponent } from './components/shared/footer/footer.component';

import { CategoryCreateComponent } from './components/administration/category/category-create/category-create.component';
import { CategoryListComponent } from './components/administration/category/category-list/category-list.component';
import { CategoryDeleteModalComponent } from './components/administration/category/category-delete-modal/category-delete-modal.component';
import { CategoryEditComponent } from './components/administration/category/category-edit/category-edit.component';
import { SongCreateComponent } from './components/user/song/song-create/song-create.component';
import { SongListComponent } from './components/user/song/song-list/song-list.component';
import { SongDeleteModalComponent } from './components/user/song/song-delete-modal/song-delete-modal.component';
import { SongEditComponent } from './components/user/song/song-edit/song-edit.component';
import { SongPlayComponent } from './home/song/song-play/song-play.component';
import { CommentListComponent } from './home/song/comment/comment-list/comment-list.component';
import { CommentInfoComponent } from './home/song/comment/comment-info/comment-info.component';
import { CommentCreateComponent } from './home/song/comment/comment-create/comment-create.component';
import { MyProfileComponent } from './components/profile/my-profile/my-profile.component';
import { ProfileEditComponent } from './components/profile/profile-edit/profile-edit.component';
import { PlaylistListComponent } from './components/user/playlist/playlist-list/playlist-list.component';
import { PlaylistCreateComponent } from './components/user/playlist/playlist-create/playlist-create.component';
import { PlaylistEditComponent } from './components/user/playlist/playlist-edit/playlist-edit.component';
import { PlaylistDeleteComponent } from './components/user/playlist/playlist-delete/playlist-delete.component';
import { SongReactionComponent } from './home/song/song-reaction/song-reaction.component';
import { CommentReactionComponent } from './home/song/comment/comment-reaction/comment-reaction.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SignupComponent,
    NavBarComponent,
    FooterComponent,
    CategoryCreateComponent,
    CategoryListComponent,
    CategoryDeleteModalComponent,
    CategoryEditComponent,
    SongCreateComponent,
    SongListComponent,
    SongDeleteModalComponent,
    SongEditComponent,
    SongPlayComponent,
    CommentListComponent,
    CommentInfoComponent,
    CommentCreateComponent,
    MyProfileComponent,
    ProfileEditComponent,
    PlaylistListComponent,
    PlaylistCreateComponent,
    PlaylistEditComponent,
    PlaylistDeleteComponent,
    SongReactionComponent,
    CommentReactionComponent,
  ],
  entryComponents: [
    CategoryDeleteModalComponent,
    CategoryEditComponent,
    SongDeleteModalComponent,
    ProfileEditComponent,
    PlaylistCreateComponent,
    PlaylistEditComponent,
    PlaylistDeleteComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: BaseUrlInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
