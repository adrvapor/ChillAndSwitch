namespace PaperPlaneTools.AR {
	using UnityEngine;
	using System.Collections;

	public class MatrixHelper {
		public static Quaternion GetQuaternion(Matrix4x4 matrix, GameObject coord) {
            // yo tocando aqui haciendo mil cosas estando durante horas para que simplemente una linea de codigo haga lo mismo xd
			Vector3 forward = new Vector3 (matrix.m02, matrix.m12, matrix.m22);
			Vector3 upwards = new Vector3 (matrix.m01, matrix.m11, matrix.m21);
            Quaternion lookRot = Quaternion.LookRotation(forward, upwards);

            //Quaternion result = Quaternion.Euler(lookRot.eulerAngles + coord.transform.rotation.eulerAngles);
            
            return lookRot;
		}

		public static Vector3 GetPosition(Matrix4x4 matrix, GameObject coord) {
            //float x = coord.transform.position.x;
            //float y = coord.transform.position.y;
            //float z = coord.transform.position.z;

            Vector3 tMat = new Vector3(matrix.m03, matrix.m13, matrix.m23 - (coord.transform.localPosition.z * 2));
            //Vector3 rotatedVector = coord.transform.rotation * tMat;

            //return new Vector3(rotatedVector.x + x, rotatedVector.y + y, rotatedVector.z + z);

            return tMat;
		}

		public static Vector3 GetScale(Matrix4x4 matrix) {
			Vector3 scale;
			scale.x = new Vector4 (matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
			scale.y = new Vector4 (matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
			scale.z = new Vector4 (matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
			return scale;
		}
	}
}