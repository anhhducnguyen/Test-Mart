import cv2
from numpy import expand_dims
from mtcnn.mtcnn import MTCNN
from keras_facenet import FaceNet
import pickle

# Load FaceNet model for embedding extraction
embedder = FaceNet()
facenet_model = embedder.model
detector = MTCNN()

# Extract face embeddings from a given frame
def get_face_embeddings(frame):
    faces = detector.detect_faces(frame)
    embeddings = []
    boxes = []
    for face in faces:
        x1, y1, width, height = face['box']
        x1, y1 = abs(x1), abs(y1)
        x2, y2 = x1 + width, y1 + height
        face_pixels = frame[y1:y2, x1:x2]
        face_pixels = cv2.resize(face_pixels, (160, 160))
        face_pixels = face_pixels.astype('float32')
        mean, std = face_pixels.mean(), face_pixels.std()
        face_pixels = (face_pixels - mean) / std
        samples = expand_dims(face_pixels, axis=0)
        yhat = facenet_model.predict(samples)
        embeddings.append(yhat[0])
        boxes.append((x1, y1, x2, y2))
    return embeddings, boxes

# Capture video from the webcam and make predictions
def realtime_face_recognition(model, out_encoder):
    cap = cv2.VideoCapture(0)
    
    while True:
        ret, frame = cap.read()
        if not ret:
            break
        
        face_embeddings, boxes = get_face_embeddings(frame)
        
        for i, face_emb in enumerate(face_embeddings):
            samples = expand_dims(face_emb, axis=0)
            yhat_class = model.predict(samples)
            yhat_prob = model.predict_proba(samples)
            class_index = yhat_class[0]
            class_probability = yhat_prob[0, class_index] * 100
            predict_name = out_encoder.inverse_transform(yhat_class)[0]
            
            x1, y1, x2, y2 = boxes[i]
            cv2.putText(frame, f'{predict_name} ({class_probability:.2f}%)', 
                        (x1, y1 - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 255, 0), 2)
            cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 255, 0), 2)
        
        cv2.imshow('Video', frame)
        
        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
    
    cap.release()
    cv2.destroyAllWindows()

def main():
    with open('svm_model/svm_model.pkl', 'rb') as model_file:
        model = pickle.load(model_file)
    with open('svm_model/out_encoder.pkl', 'rb') as encoder_file:
        out_encoder = pickle.load(encoder_file)

    realtime_face_recognition(model, out_encoder)

if __name__ == "__main__":
    main()


# import cv2
# import numpy as np  # Thêm dòng này
# from mtcnn.mtcnn import MTCNN
# from keras_facenet import FaceNet
# import pickle

# # Load FaceNet model for embedding extraction
# embedder = FaceNet()
# facenet_model = embedder.model
# detector = MTCNN()

# # Load the trained Passive Aggressive model and label encoder
# def load_model_and_labels(model_path, labels_path):
#     with open(model_path, 'rb') as model_file:
#         pa_model = pickle.load(model_file)
#     with open(labels_path, 'rb') as labels_file:
#         all_labels = pickle.load(labels_file)
#     return pa_model, all_labels

# # Extract face embeddings from a given frame
# def get_face_embeddings(frame):
#     faces = detector.detect_faces(frame)
#     embeddings = []
#     boxes = []
#     for face in faces:
#         x1, y1, width, height = face['box']
#         x1, y1 = abs(x1), abs(y1)
#         x2, y2 = x1 + width, y1 + height
#         face_pixels = frame[y1:y2, x1:x2]
#         face_pixels = cv2.resize(face_pixels, (160, 160))
#         face_pixels = face_pixels.astype('float32')
#         mean, std = face_pixels.mean(), face_pixels.std()
#         face_pixels = (face_pixels - mean) / std
#         samples = np.expand_dims(face_pixels, axis=0)  # Thay đổi dòng này
#         yhat = facenet_model.predict(samples)
#         embeddings.append(yhat[0])
#         boxes.append((x1, y1, x2, y2))
#     return embeddings, boxes

# # Predict labels for faces in a frame
# def predict_labels(frame, pa_model, all_labels):
#     face_embeddings, boxes = get_face_embeddings(frame)
    
#     for i, face_emb in enumerate(face_embeddings):
#         samples = np.expand_dims(face_emb, axis=0)
#         yhat_class = pa_model.predict(samples)
#         if isinstance(yhat_class[0], str):  # Kiểm tra nếu nhãn là một chuỗi
#             predict_name = yhat_class[0]  # Giữ nguyên nhãn chuỗi
#         else:
#             class_index = int(yhat_class[0])  # Chuyển đổi sang số nguyên
#             predict_name = all_labels[class_index]  # Lấy nhãn từ danh sách nhãn
#         x1, y1, x2, y2 = boxes[i]
#         cv2.putText(frame, predict_name, (x1, y1 - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 255, 0), 2)
#         cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 255, 0), 2)
#     return frame




# # Capture video from the webcam and make predictions
# def realtime_face_recognition():
#     pa_model, all_labels = load_model_and_labels('pa_model.pkl', 'all_labels.pkl')
#     cap = cv2.VideoCapture(0)
    
#     while True:
#         ret, frame = cap.read()
#         if not ret:
#             break
        
#         frame = predict_labels(frame, pa_model, all_labels)
        
#         cv2.imshow('Video', frame)
        
#         if cv2.waitKey(1) & 0xFF == ord('q'):
#             break
    
#     cap.release()
#     cv2.destroyAllWindows()

# if __name__ == "__main__":
#     realtime_face_recognition()











