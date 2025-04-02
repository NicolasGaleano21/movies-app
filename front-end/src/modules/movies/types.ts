export interface Actor {
  name: string;
}

export interface Genre {
  description: string;
}

export interface Movie {
  id: number;
  title: string;
  actors: Actor[];
  genres: Genre[];
}

export interface GetMoviesParams {
  searchType: string;
  searchValue: string;
  pageNumber: number;
  pageSize: number;
}

export interface MovieResult {
  totalRows: number,
  rows: Movie[]
}
