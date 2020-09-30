import { Song } from './song';
import User from './user';

export default interface Playlist {
  id: string,
  name: string,
  playlistSongsCount: number,
  songs: Array<Song>[],
  user: User,
}
