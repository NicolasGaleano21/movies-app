import { AppDispatch } from "../../../data/store";
import { hideSpinner, showAlert, showSpinner } from "../../global/data/globalSlice";
import { GetMoviesParams } from "../types";
import { MoviesServices } from "./moviesServices";
import { setMoviesResult } from "./moviesSlice";

export const getMovies = (params: GetMoviesParams) => async (dispatch: AppDispatch) => {
  dispatch(showSpinner())
  try {
    const { getMovies } = new MoviesServices();
    const movies = await getMovies(params)
    dispatch(setMoviesResult(movies.data))
  } catch(error)
  {
    dispatch(showAlert({type: "error", message: error}))
  } finally{
    dispatch(hideSpinner())
  }
};