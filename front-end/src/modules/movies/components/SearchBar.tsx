import { Clear, Search } from "@mui/icons-material";
import { IconButton, InputAdornment, TextField } from "@mui/material";
import { PageData } from "../../global/types";
import { useCallback } from "react";

interface SearchBarProps {
  search: { type: string; value: string };
  setSearch: React.Dispatch<
    React.SetStateAction<{ type: string; value: string }>
  >;
  disabledSearch: boolean;
  setDisabledSearch: React.Dispatch<React.SetStateAction<boolean>>;
  setPageData: React.Dispatch<React.SetStateAction<PageData>>;
}

export const SearchBar = ({
  search,
  setSearch,
  disabledSearch,
  setDisabledSearch,
  setPageData
}: SearchBarProps) => {
    const resetPage = useCallback(() => {
      setPageData((prev) => ({ ...prev, page: 1 }));
    }, []);
  return (
    <TextField
      label={`Search by ${search.type}`}
      onChange={(e) => setSearch({ ...search, value: e.target.value })}
      value={search.value}
      disabled={disabledSearch}
      fullWidth
      autoComplete="off"
      onKeyDown={(e) => {
        if (e.code === "Enter" && search.value !== "") {
          resetPage()
          setDisabledSearch(true)
        };
      }}
      InputProps={{
        endAdornment: (
          <InputAdornment position="end">
            {disabledSearch && search.value !== "" ? (
              <IconButton
                onClick={() => {
                  setDisabledSearch(false);
                  resetPage()
                  setSearch({ ...search, value: "" });
                }}
              >
                <Clear />
              </IconButton>
            ) : (
              <IconButton
                onClick={() => {
                  resetPage()
                  setDisabledSearch(true)
                }}
                disabled={search.value === ""}
              >
                <Search />
              </IconButton>
            )}
          </InputAdornment>
        ),
      }}
    />
  );
};
