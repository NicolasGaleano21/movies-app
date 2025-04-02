import { Grid } from "@mui/material";
import { MovieCard } from "../templates/MovieCard";
import { Movie } from "../types";

export const MoviesList = ({ movies } : {movies: Movie[]}) => {
  return (
    <>
      {movies.map((movie) => (
        <Grid size={{lg: 4, md: 6, sm : 12}} key={movie.id}>
          <MovieCard movie={movie} />
        </Grid>
      ))}
    </>
  );
};
