import Comment from './comment';
import User from './user';

export interface Song {
  id: string,
  name: string,
  path: string,
  imageFile: File,
  imagePath: string,
  songCategoryId: string,
  songCategoryName: string,
  text: string,
  countViews: string,
  countLikes: 0,
  countDisLikes: 0,
  createdOn: Date,
  comments: Array<Comment>,
  user: User,
}
