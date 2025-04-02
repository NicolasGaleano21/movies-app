import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { MovieResult } from "../types";

interface MoviesState {
  moviesResult: MovieResult;
}

const initialState: MoviesState = {
  moviesResult: {totalRows: 0, rows: []},
};

const moviesSlice = createSlice({
  name: "movies",
  initialState,
  reducers: {
    setMoviesResult: (state, action: PayloadAction<MovieResult>) => {
      state.moviesResult = action.payload;
    },
  },
});

export const { setMoviesResult } = moviesSlice.actions;
export default moviesSlice.reducer;
