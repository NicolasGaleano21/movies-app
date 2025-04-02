import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";
import { useSelector } from "react-redux";
import { RootState } from "../../data/store";

export default function Spinner() {
  const { showSpinner } = useSelector((state: RootState) => state.global);
  return (
    <div>
      <Backdrop
        sx={(theme) => ({ color: "#fff", zIndex: theme.zIndex.modal + 1 })}
        open={showSpinner}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  );
}
