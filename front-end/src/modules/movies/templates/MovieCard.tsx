import { Card, CardContent, Typography, Tooltip } from "@mui/material";
import { Movie } from "../types";

export const MovieCard = ({ movie }: { movie: Movie }) => {
  return (
    <Card sx={{ minWidth: 275, padding: 2 }}>
      <CardContent>
        <Typography variant="h6" component="div">
          {movie.title}
        </Typography>
        <Typography color="text.secondary">
          Genres: {movie.genres.map((g) => g.description).join(", ")}
        </Typography>
        <Tooltip title={movie.actors.map((a) => a.name).join(", ")} arrow>
          <Typography
            variant="body2"
            sx={{
              overflow: "hidden",
              textOverflow: "ellipsis",
              whiteSpace: "nowrap",
              display: "block",
            }}
          >
            Actors: {movie.actors.map((a) => a.name).join(", ")}
          </Typography>
        </Tooltip>
      </CardContent>
    </Card>
  );
};
