export interface Song {
  id: number,
  name: string
  path: string,
  imageFile: File,
  imagePath: string,
  musicCategoryId: string,
  musicCategoryName: string,
  text: string,
  countViews: string,
  countLikes: 0,
  countDisLikes: 0,
  createdOn: Date,
  commentars: [],
}
