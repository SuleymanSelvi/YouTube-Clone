import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private http: HttpClient) { }

  // USER COMPONENT

  registir(name: any, password: any, about: any) {
    return this.http.post("https://localhost:7093/api/User/Registir", {
      "name": name,
      "password": password,
      "about": about
    })
  }

  login(name: any, password: any) {
    return this.http.post("https://localhost:7093/api/User/Login", {
      "name": name,
      "password": password
    })
  }

  getUserDetail(name: any, sessionId: any) {
    return this.http.get("https://localhost:7093/api/User/GetUserDetail?name=" + name + "&sessionId=" + sessionId)
  }

  // HOME COMPONENT

  getAllVideos() {
    return this.http.get("https://localhost:7093/Videos/GetAllVideos")
  }

  searchVideo(videoName: any, date: any, duration: any, sort: any) {
    return this.http.get("https://localhost:7093/Videos/SearchVideo?videoName=" + videoName + "&date=" + date + "&duration=" + duration + "&sort=" + sort)
  }

  getCategories() {
    return this.http.get("https://localhost:7093/api/Categories/GetCategories")
  }

  getVideoByCategoriesId(id: any) {
    return this.http.get("https://localhost:7093/Videos/GetVideoByCategoriesId?id=" + id)
  }

  getVideoByUserId(name: any) {
    return this.http.get("https://localhost:7093/Videos/GetVideoByUserId?name=" + name)
  }

  // WATCH COMPONENT

  getVideoById(videoId: any, sessionId: any) {
    return this.http.get("https://localhost:7093/Videos/GetVideoById?videoId=" + videoId + "&sessionId=" + sessionId)
  }

  getCommentByVideoId(videoId: any) {
    return this.http.get("https://localhost:7093/api/VideosComment/GetCommentByVideoId?videoId=" + videoId)
  }

  uploadComment(userId: any, videoId: any, comment: any, subCommentId: any) {
    return this.http.post("https://localhost:7093/api/VideosComment/UploadComment", {
      "userId": userId,
      "videoId": videoId,
      "comment": comment,
      "subCommentId": subCommentId
    })
  }

  videoLike(videoId: any, userId: any) {
    return this.http.post("https://localhost:7093/api/VideoLike/VideoLike", {
      "videoId": videoId,
      "userId": userId
    })
  }

  videoSaved(videoId: any, userId: any) {
    return this.http.post("https://localhost:7093/api/VideoSaved/VideoSaved", {
      "videoId": videoId,
      "userId": userId
    })
  }

  videoView(videoId: any, userId: any) {
    return this.http.post("https://localhost:7093/api/VideoView/VideoView", {
      "videoId": videoId,
      "userId": userId
    })
  }

  // SUBSCRIBERS

  subscribers(followedId: any, followingId: any) {
    return this.http.post("https://localhost:7093/api/Subscribers/newSubscribers", {
      "followedId": followedId,
      "followingId": followingId
    })
  }

  getUserSubscribers(id: any) {
    return this.http.get("https://localhost:7093/api/Subscribers/GetUserSubscribers?id=" + id)
  }

  // PLAYLIST

  getPlaylistsByUserId(name: any) {
    return this.http.get("https://localhost:7093/api/Playlists/GetPlaylistsByUserId?name=" + name)
  }

  newPlaylist(userId: any, name: any) {
    return this.http.post("https://localhost:7093/api/Playlists/NewPlaylist", {
      "userId": userId,
      "name": name
    })
  }

  // PLAYLIST VIDEOS
  getVideosByPlaylists(playlistId: any) {
    return this.http.get("https://localhost:7093/api/PlaylistVideos/GetVideosByPlaylists?playlistId=" + playlistId)
  }

  newPlaylistVideo(userId: any, videoId: any, playlistId: any) {
    return this.http.post("https://localhost:7093/api/PlaylistVideos/newPlaylistVideo", {
      "userId": userId,
      "videoId": videoId,
      "playlistId": playlistId
    })
  }

}
