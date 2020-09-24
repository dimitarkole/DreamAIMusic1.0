import { Song } from './song';

export default interface Playlist {
  id: string,
  name: string,
  playlistSongsCount: number,
  songs: Array<Song>[],
}
