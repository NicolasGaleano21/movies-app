import ServiceBase from "../../../data/serviceBase";
import { GetMoviesParams, MovieResult } from "../types";

export class MoviesServices extends ServiceBase {
  getMovies = async (params: GetMoviesParams) => this.client.get<MovieResult>("Movies", { params });
}
