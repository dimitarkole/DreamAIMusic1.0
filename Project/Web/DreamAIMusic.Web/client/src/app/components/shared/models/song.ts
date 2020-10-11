import Comment from './comment';
import User from './user';
import { Reaction } from './reaction';

export interface Song {
  id: string,
  name: string,
  uniqueSongFilesName: string,
  songCategoryId: string,
  songCategoryName: string,
  text: string,
  countViews: string,
  countLikes: 0,
  countDisLikes: 0,
  createdOn: Date,
  comments: Array<Comment>,
  user: User,
  imageExtension: string,
  mp3Extension: string,
  reaction : Reaction,
}
