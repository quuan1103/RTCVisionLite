Tool: IMAGEFILTER

Run(): Chạy tool FindLine
	-INPUT:
		+ Bitmap InputImage: Ảnh input.
		+ int MaskWidth: Chiều rộng mặt nạ.
		+ int MaskHeight: Chiều cao mặt nạ.
		+ string MaskType: Kiểu mặt nạ.
			. "Rectangle"
			. "Cross"
			. "Ellipse"
		+ Tuple<int, int> ThresholdRange: Ngưỡng Threshold.
		+ int GrayValue: Giá trị xám.
		+ double ScaleFactor: Scale Factor.
		+ string FilterType
			. "Opening" (input: InputImage, MaskType, MaskWidth, MaskHeight)
			. "Closing" (input: InputImage, MaskType, MaskWidth, MaskHeight)
			. "Dilation" (input: InputImage, MaskType, MaskWidth, MaskHeight)
			. "Erosion" (input: InputImage, MaskType, MaskWidth, MaskHeight)
			. "Mean" (input: InputImage, MaskWidth, MaskHeight)
			. "Median" (input: InputImage, MaskWidth)
			. "Gaussian" (input: InputImage, MaskWidth)
			. "Binary" (input: InputImage, ThresholdRange)
			. "Invert"  (input: InputImage)
			. "Band Pass" (input: InputImage)
			. "Emphasize" (input: InputImage, MaskWidth, MaskHeight)
			. "Blue" (input: InputImage)
			. "Green" (input: InputImage)
			. "Red" (input: InputImage)
			. "Hue" (input: InputImage)
			. "Saturation" (input: InputImage)
			. "Intensity" (input: InputImage)
			. "RGB To Gray" (input: InputImage)
			
	-OUTPUT:
		+ bool Passed: nếu true : passed; nếu fasle: failed.
		+ string ErrMessage: message lỗi.
		+ Bitmap OutputImage: Ảnh output.

