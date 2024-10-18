import axios from "axios";
import { v4 as uuidv4 } from "uuid";

import { Square } from "../shared/types";

const API_BASE_URL = __API_BASE_URL__;

const instance = axios.create({
  baseURL: API_BASE_URL,
  withCredentials: true,
});

const STORAGE_USER_ID_KEY = "user_id";

instance.interceptors.request.use((config) => {
  let guid = sessionStorage.getItem(STORAGE_USER_ID_KEY);

  if (guid === null) {
    guid = uuidv4();
    sessionStorage.setItem(STORAGE_USER_ID_KEY, guid as string);
  }

  config.headers["user_id"] = guid;
  return config;
});

export const addSquare = (newSquare: Square) => {
  return instance({
    method: "POST",
    url: "/squares/add",
    data: {
      ...newSquare,
    },
    withCredentials: true,
  }).then((res) => res.data);
};

export const getSquares = () => {
  return instance({
    method: "GET",
    url: "/squares/get",
  }).then((res) => res.data);
};
