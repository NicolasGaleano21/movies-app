import { useCallback, useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../data/store";
import { getMovies } from "./data/moviesActions";
import { PageData } from "../global/types";
import { Grid, TablePagination } from "@mui/material";
import { DropdownButton } from "../../components/DropdownButton";
import { MoviesList } from "./components/MoviesList";
import { SearchBar } from "./components/SearchBar";

const MoviesPage = () => {
  const [search, setSearch] = useState({ type: "title", value: "" });
  const [disabledSearch, setDisabledSearch] = useState(false);
  const [pageData, setPageData] = useState<PageData>({ page: 1, pageSize: 5 });
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    dispatch(
      getMovies({
        pageNumber: pageData.page,
        pageSize: pageData.pageSize,
        searchType: search.type,
        searchValue: search.value,
      })
    );
  }, [pageData?.page, pageData?.pageSize, disabledSearch, search.type]);

  const { moviesResult } = useSelector((state: RootState) => state.movies);

  const dropdownOptions = useMemo(
    () => [
      {
        label: "Title",
        onClick: () => {
          setSearch((prev) => ({ ...prev, type: "title" }));
        },
      },
      {
        label: "Genre",
        onClick: () => {
          setSearch((prev) => ({ ...prev, type: "genre" }));
        },
      },
      {
        label: "Actor",

        onClick: () => {
          setSearch((prev) => ({ ...prev, type: "actor" }));
        },
      },
    ],
    []
  );

  const handlePageChange = useCallback((_e: unknown, pageNumber: number) => {
    setPageData((prev) => ({ ...prev, page: pageNumber + 1 }));
  }, []);

  const handleRowsPerPageChange = useCallback(
    (event: React.ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
      setPageData({ page: 1, pageSize: parseInt(event.target.value) });
    },
    []
  );

  return (
    <Grid container spacing={3} padding={10}>
      <Grid size={9} mb={2}>
        <SearchBar
          {...{
            search,
            setSearch,
            disabledSearch,
            setDisabledSearch,
            setPageData,
          }}
        />
      </Grid>
      <Grid size={3}>
        <DropdownButton options={dropdownOptions} />
      </Grid>
      <MoviesList movies={moviesResult.rows} />
      <Grid size={12}>
        <TablePagination
          component="div"
          count={moviesResult.totalRows}
          page={pageData.page - 1}
          rowsPerPageOptions={[5, 10, 15]}
          onPageChange={handlePageChange}
          rowsPerPage={pageData.pageSize}
          onRowsPerPageChange={handleRowsPerPageChange}
        />
      </Grid>
    </Grid>
  );
};

export default MoviesPage;
