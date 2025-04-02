import Snackbar from "@mui/material/Snackbar";
import Slide from "@mui/material/Slide";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../../../data/store";
import { hideAlert } from "../data/globalSlice";
import { TransitionProps } from "@mui/material/transitions";
import { Alert } from "@mui/material";

const Transition = (
  props: TransitionProps & {
    children: React.ReactElement<any, any>;
  }
) => <Slide {...props} direction="up" />;

export const AlertMessage = () => {
  const dispatch = useDispatch();
  const { alert } = useSelector((state: RootState) => state.global);
  const handleClose = (
    _event?: React.SyntheticEvent | Event,
    reason?: string
  ) => {
    if (reason === "clickaway") {
      return;
    }
    dispatch(hideAlert());
  };

  return (
    <Snackbar
      open={alert.show}
      onClose={handleClose}
      message={alert.message}
      autoHideDuration={3000}
      anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
      key={Transition.name}
      action={
        <IconButton
          size="small"
          aria-label="close"
          color="inherit"
          onClick={handleClose}
        >
          <CloseIcon fontSize="small" />
        </IconButton>
      }
    >
      <Alert
        onClose={handleClose}
        severity={alert.type}
        variant="filled"
        sx={{ width: "100%", fontSize: "medium" }}
      >
        {alert.message}
      </Alert>
    </Snackbar>
  );
};
