class Object {
}

class extensions {
}

class RegisterRequest {
    email?: string;
    userName?: string;
    password?: string;

    constructor(data: any) {
        this.email = data["email"];
        this.userName = data["userName"];
        this.password = data["password"];
    }

    static fromResponse(data?: any): RegisterRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RegisterRequest(_data);        
        return _response;
    }
}

class AuthSuccessResponse {
    token?: string;
    refreshToken?: string;
    success?: boolean;

    constructor(data: any) {
        this.token = data["token"];
        this.refreshToken = data["refreshToken"];
        this.success = data["success"];
    }

    static fromResponse(data?: any): AuthSuccessResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AuthSuccessResponse(_data);        
        return _response;
    }
}

class LoginRequest {
    email?: string;
    password?: string;

    constructor(data: any) {
        this.email = data["email"];
        this.password = data["password"];
    }

    static fromResponse(data?: any): LoginRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new LoginRequest(_data);        
        return _response;
    }
}

class LogoutRequest {
    token?: string;

    constructor(data: any) {
        this.token = data["token"];
    }

    static fromResponse(data?: any): LogoutRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new LogoutRequest(_data);        
        return _response;
    }
}

class RefreshRequest {
    token?: string;
    refreshToken?: string;

    constructor(data: any) {
        this.token = data["token"];
        this.refreshToken = data["refreshToken"];
    }

    static fromResponse(data?: any): RefreshRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RefreshRequest(_data);        
        return _response;
    }
}

class ProblemDetails {
    type: string;
    title: string;
    status: number;
    detail: string;
    instance: string;
    extensions: extensions;

    constructor(data: any) {
        this.type = data["type"];
        this.title = data["title"];
        this.status = data["status"];
        this.detail = data["detail"];
        this.instance = data["instance"];
        this.extensions = data["extensions"];
    }

    static fromResponse(data?: any): ProblemDetails {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ProblemDetails(_data);        
        return _response;
    }
}

class MetricResponse {
    unit: string;
    value: number;

    constructor(data: any) {
        this.unit = data["unit"];
        this.value = data["value"];
    }

    static fromResponse(data?: any): MetricResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new MetricResponse(_data);        
        return _response;
    }
}

class UsResponse {
    unit: string;
    value: number;

    constructor(data: any) {
        this.unit = data["unit"];
        this.value = data["value"];
    }

    static fromResponse(data?: any): UsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new UsResponse(_data);        
        return _response;
    }
}

class TemperatureResponse {
    number: number;
    unit: string;

    constructor(data: any) {
        this.number = data["number"];
        this.unit = data["unit"];
    }

    static fromResponse(data?: any): TemperatureResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new TemperatureResponse(_data);        
        return _response;
    }
}

class PhotoResponse {
    id: number;
    image: string;
    name: string;

    constructor(data: any) {
        this.id = data["id"];
        this.image = data["image"];
        this.name = data["name"];
    }

    static fromResponse(data?: any): PhotoResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new PhotoResponse(_data);        
        return _response;
    }
}

class UpdateCurrentUserRequest {
    userName: string;
    userSurname: string;
    age: number;
    description: string;
    phoneNumber: string;

    constructor(data: any) {
        this.userName = data["userName"];
        this.userSurname = data["userSurname"];
        this.age = data["age"];
        this.description = data["description"];
        this.phoneNumber = data["phoneNumber"];
    }

    static fromResponse(data?: any): UpdateCurrentUserRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new UpdateCurrentUserRequest(_data);        
        return _response;
    }
}

class ChangeCurrentUserPasswordRequest {
    oldPassword?: string;
    newPassword?: string;

    constructor(data: any) {
        this.oldPassword = data["oldPassword"];
        this.newPassword = data["newPassword"];
    }

    static fromResponse(data?: any): ChangeCurrentUserPasswordRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ChangeCurrentUserPasswordRequest(_data);        
        return _response;
    }
}

class WidgetResponse {
    code: string;
    defaultCss: boolean;

    constructor(data: any) {
        this.code = data["code"];
        this.defaultCss = data["defaultCss"];
    }

    static fromResponse(data?: any): WidgetResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new WidgetResponse(_data);        
        return _response;
    }
}

class AmountResponse {
    metric: MetricResponse;
    us: UsResponse;

    constructor(data: any) {
        this.metric = data["metric"];
        this.us = data["us"];
    }

    static fromResponse(data?: any): AmountResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AmountResponse(_data);        
        return _response;
    }
}

class EquipmentResponse {
    id: number;
    name: string;
    temperature: TemperatureResponse;

    constructor(data: any) {
        this.id = data["id"];
        this.name = data["name"];
        this.temperature = data["temperature"];
    }

    static fromResponse(data?: any): EquipmentResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new EquipmentResponse(_data);        
        return _response;
    }
}

class AuthFailedResponse {
    success?: boolean;
    errors?: Array<string>;

    constructor(data: any) {
        this.success = data["success"];
        this.errors = [] as any;
        if (Array.isArray(data["errors"])) {
            for (let _item of data["errors"]) {
                this.errors!!.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): AuthFailedResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new AuthFailedResponse(_data);        
        return _response;
    }
}

class FiledErrors {
    field?: string;
    messages?: Array<string>;

    constructor(data: any) {
        this.field = data["field"];
        this.messages = [] as any;
        if (Array.isArray(data["messages"])) {
            for (let _item of data["messages"]) {
                this.messages!!.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): FiledErrors {
        const _data = typeof data === 'object' ? data : {};
        const _response = new FiledErrors(_data);        
        return _response;
    }
}

class IngredientsResponse {
    image: string;
    name: string;
    amount: AmountResponse;

    constructor(data: any) {
        this.image = data["image"];
        this.name = data["name"];
        this.amount = data["amount"];
    }

    static fromResponse(data?: any): IngredientsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new IngredientsResponse(_data);        
        return _response;
    }
}

class IngredientsRequest {
    ingredients: Array<string>;

    constructor(data: any) {
        this.ingredients = [] as any;
        if (Array.isArray(data["ingredients"])) {
            for (let _item of data["ingredients"]) {
                this.ingredients.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): IngredientsRequest {
        const _data = typeof data === 'object' ? data : {};
        const _response = new IngredientsRequest(_data);        
        return _response;
    }
}

class Ingredient {
    aisle: string;
    amount: number;
    id: number;
    image: string;
    name: string;
    original: string;
    originalName: string;
    originalString: string;
    unit: string;
    unitLong: string;
    unitShort: string;
    metaInformation: Array<string>;

    constructor(data: any) {
        this.aisle = data["aisle"];
        this.amount = data["amount"];
        this.id = data["id"];
        this.image = data["image"];
        this.name = data["name"];
        this.original = data["original"];
        this.originalName = data["originalName"];
        this.originalString = data["originalString"];
        this.unit = data["unit"];
        this.unitLong = data["unitLong"];
        this.unitShort = data["unitShort"];
        this.metaInformation = [] as any;
        if (Array.isArray(data["metaInformation"])) {
            for (let _item of data["metaInformation"]) {
                this.metaInformation.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): Ingredient {
        const _data = typeof data === 'object' ? data : {};
        const _response = new Ingredient(_data);        
        return _response;
    }
}

class StepInstructionReponse {
    number: number;
    step: string;
    ingredients: Array<PhotoResponse>;
    equipment: Array<EquipmentResponse>;

    constructor(data: any) {
        this.number = data["number"];
        this.step = data["step"];
        this.ingredients = [] as any;
        if (Array.isArray(data["ingredients"])) {
            for (let _item of data["ingredients"]) {
                this.ingredients.push(_item);
                
            }
        }
        this.equipment = [] as any;
        if (Array.isArray(data["equipment"])) {
            for (let _item of data["equipment"]) {
                this.equipment.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): StepInstructionReponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new StepInstructionReponse(_data);        
        return _response;
    }
}

class ValidationFailedResponse {
    status?: boolean;
    errors?: Array<FiledErrors>;

    constructor(data: any) {
        this.status = data["status"];
        this.errors = [] as any;
        if (Array.isArray(data["errors"])) {
            for (let _item of data["errors"]) {
                this.errors!!.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): ValidationFailedResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new ValidationFailedResponse(_data);        
        return _response;
    }
}

class RecipesPriceBreakdownResponse {
    totalCost: number;
    totalCostPerServing: number;
    ingredients: Array<IngredientsResponse>;

    constructor(data: any) {
        this.totalCost = data["totalCost"];
        this.totalCostPerServing = data["totalCostPerServing"];
        this.ingredients = [] as any;
        if (Array.isArray(data["ingredients"])) {
            for (let _item of data["ingredients"]) {
                this.ingredients.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): RecipesPriceBreakdownResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipesPriceBreakdownResponse(_data);        
        return _response;
    }
}

class RecipeIngredientsResponse {
    ingredients: Array<IngredientsResponse>;

    constructor(data: any) {
        this.ingredients = [] as any;
        if (Array.isArray(data["ingredients"])) {
            for (let _item of data["ingredients"]) {
                this.ingredients.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): RecipeIngredientsResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeIngredientsResponse(_data);        
        return _response;
    }
}

class RecipeResponse {
    id: number;
    image: string;
    imageType: string;
    likes: number;
    missedIngredientCount: number;
    title: string;
    usedIngredientCount: number;
    missedIngredients: Array<Ingredient>;
    unusedIngredients: Array<Ingredient>;
    usedIngredients: Array<Ingredient>;

    constructor(data: any) {
        this.id = data["id"];
        this.image = data["image"];
        this.imageType = data["imageType"];
        this.likes = data["likes"];
        this.missedIngredientCount = data["missedIngredientCount"];
        this.title = data["title"];
        this.usedIngredientCount = data["usedIngredientCount"];
        this.missedIngredients = [] as any;
        if (Array.isArray(data["missedIngredients"])) {
            for (let _item of data["missedIngredients"]) {
                this.missedIngredients.push(_item);
                
            }
        }
        this.unusedIngredients = [] as any;
        if (Array.isArray(data["unusedIngredients"])) {
            for (let _item of data["unusedIngredients"]) {
                this.unusedIngredients.push(_item);
                
            }
        }
        this.usedIngredients = [] as any;
        if (Array.isArray(data["usedIngredients"])) {
            for (let _item of data["usedIngredients"]) {
                this.usedIngredients.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): RecipeResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeResponse(_data);        
        return _response;
    }
}

class RecipeInstructionResponse {
    name: string;
    steps: Array<StepInstructionReponse>;

    constructor(data: any) {
        this.name = data["name"];
        this.steps = [] as any;
        if (Array.isArray(data["steps"])) {
            for (let _item of data["steps"]) {
                this.steps.push(_item);
                
            }
        }
    }

    static fromResponse(data?: any): RecipeInstructionResponse {
        const _data = typeof data === 'object' ? data : {};
        const _response = new RecipeInstructionResponse(_data);        
        return _response;
    }
}

export { Object, extensions, RegisterRequest, AuthSuccessResponse, LoginRequest, LogoutRequest, RefreshRequest, ProblemDetails, MetricResponse, UsResponse, TemperatureResponse, PhotoResponse, UpdateCurrentUserRequest, ChangeCurrentUserPasswordRequest, WidgetResponse, AmountResponse, EquipmentResponse, AuthFailedResponse, FiledErrors, IngredientsResponse, IngredientsRequest, Ingredient, StepInstructionReponse, ValidationFailedResponse, RecipesPriceBreakdownResponse, RecipeIngredientsResponse, RecipeResponse, RecipeInstructionResponse };
