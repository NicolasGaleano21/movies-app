import { configureStore } from '@reduxjs/toolkit';
import globalSlice from '../modules/global/data/globalSlice';
import moviesSlice from '../modules/movies/data/moviesSlice';

const store = configureStore({
  reducer: {
    global: globalSlice,
    movies: moviesSlice
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
