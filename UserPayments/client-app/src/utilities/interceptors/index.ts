import Axios, { AxiosError } from "axios";
import type { ResponseBase } from "@/viewmodels/shared";
import { ResponseBaseTypeEnum } from "../shared/enums";
import type { Router } from "vue-router";

export default {
  ConfigureInterceptors(router: Router) {
    Axios.interceptors.response.use(
      (response) => {
        const responseBase = response?.data as ResponseBase<any>;

        if (responseBase?.Type) {
          if (responseBase.Type == ResponseBaseTypeEnum.Success) {
            response.data = responseBase.Result;
          }
          else {
            alert(responseBase.Messages);
            return Promise.reject();
          }
        }

        return response;
      },
      
      (error: AxiosError) => {
        alert(error.message);
        return Promise.reject(error);
      }
    );
  }
}
