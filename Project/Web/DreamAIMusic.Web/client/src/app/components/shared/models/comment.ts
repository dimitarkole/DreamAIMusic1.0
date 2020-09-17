import User from './user';

export default interface Comment {
  id: string,
  songId: string,
  parentCommentId: string,
  text: string,
  commentLikesCount: number,
  commentDislikesCount: number,
  commentsChildren: Array<Comment>,
  user: User,
  createdOn: Date
}
